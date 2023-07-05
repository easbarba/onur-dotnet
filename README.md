<!--
Onur is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Onur is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Onur. If not, see <https://www.gnu.org/licenses/>.
-->

# Onur

Easily manage multiple FLOSS repositories

`Onur` grab all repositories listed in the configuration files.

[python](https://gitlab.com/easbarba/onur) | [ruby](https://gitlab.com/easbarba/onur.rb) | [golang](https://gitlab.com/easbarba/onur_go)

# Installation

## Usage

`Onur` consumes configurations files at `$XDG_CONFIG/onur`.

```json
onur grab
onur archive nuxt,awesomewm,guzzle
```

- `$ONUR_CONFIG_HOME` environment variable is available to define a new location of configuration files.
- repositories are stored in the `$HOME/Projects` folder.

## Configuration file

A `onur` configuration file is just a single list providing name and url of projects, branch may be provided if not the usual `master` branch:

```json
[
  {
    "name": "awesomewm",
    "url": "https://github.com/awesomeWM/awesome"
  },
  {
    "name": "nuxt",
    "branch": "main",
    "url": "https://github.com/nuxt/framework"
  }
]
```

More examples of configuration files are at `examples`.

## Settings

A TOML settings file may define the behavior of `onur`:

```toml
[base]
single-branch = true
quiet = true
depth = 1

```

## Options

Consult `onur --help` for more options.

## GNU Guix

In a system with GNU Guix binary installed, its even easier to grab all
dependencies: `guix shell`.

## LICENSE

[GNU GENERAL PUBLIC LICENSE Version 3](https://www.gnu.org/licenses/gpl-3.0.en.html)
