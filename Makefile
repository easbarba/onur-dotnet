# Onur is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# Onur is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with Onur. If not, see <https://www.gnu.org/licenses/>.

# DEPENDENCIES: gawk, fzf, podman

.DEFAULT_GOAL := test

NAME := onur-dotnet
VERSION := $(shell awk '/<Version>/ {version=substr($$0,14,5); print version}' ./Onur/Onur.csproj)
IMAGENAME := registry.gitlab.com/${USER}/${NAME}:${VERSION}
RUNNER ?= podman

.PHONY: test
test:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${IMAGENAME} \
		bash -c 'dotnet test --verbosity normal'

.PHONY: grab
grab:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${IMAGENAME} \
		bash -c 'dotnet run --project Onur grab'

.PHONY: archive
archive:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${IMAGENAME} \
		bash -c 'dotnet run --project Onur archive awesomewm,river,stumpwm'

.PHONY: command
command:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${IMAGENAME} \
		bash -c '$(shell cat container-commands | fzf)'

.PHONY: image.repl
image.repl:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${IMAGENAME} \
		bash -c 'ls'

.PHONY: image.build
image.build:
	${RUNNER} build --file ./Containerfile --tag ${IMAGENAME}

.PHONY: image.publish
image.publish:
	${RUNNER} push ${IMAGENAME}

.PHONY: install
install:
	dotnet publish \
	--self-contained true \
	--configuration Release \
	--runtime linux-x64 \
	--output ${HOME}/.local/onur
	ln -sf ${HOME}/.local/onur/Onur ${HOME}/.local/bin/onur

.PHONY: system
system:
	guix shell --pure --container
