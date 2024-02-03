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

NAME := onur
VERSION := $(shell cat .version)
FULLNAME := ${USER}/${NAME}:${VERSION}

RUNNER ?= podman
REPL_CONTAINER := mcr.microsoft.com/dotnet/sdk:8.0

command:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${REPL_CONTAINER} \
		bash -c './prepare.bash && $(shell cat container-commands | fzf)'

grab:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${REPL_CONTAINER} \
		bash -c 'dotnet run --project Onur grab'

archive:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${REPL_CONTAINER} \
		bash -c './prepare.bash && dotnet run --project Onur archive awesomewm,river,stumpwm'

repl:
	${RUNNER} run --rm -it \
		--volume ${PWD}:/app:Z \
		--workdir /app \
		${REPL_CONTAINER} \
		bash -c './prepare.bash && bash'

build:
	${RUNNER} build --file ./Containerfile --tag ${FULLNAME}

.PHONY: test repl build command native grab archive
.DEFAULT_GOAL := test
