# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.6.0] - 2024-03-05
### Deprecated
- Deprecated `Instance.State` property in favour of `Instance.GetStateAsync()` method.
### Added
- Added Blazor Server support.

## [0.5.1] - 2023-08-02
### Added
- Added `TogglePopperComponent` abstraction.

## [0.4.0] - 2021-12-27
### Added
- Added `PopperComponent` abstraction.
### Fixed
- Fixed that the `Options` class could not always be serialized when sent to .NET due to circular references.

## [0.3.0] - 2021-08-09
### Added
- Added support for creating an `Instance` from a `VirtualElement`.