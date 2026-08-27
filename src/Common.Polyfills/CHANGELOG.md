# Changelog - JK.Common.Polyfills

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Unless otherwise noted, all changes made by [@jeremyknight-me](https://github.com/jeremyknight-me).

## 1.0.0 - Unreleased

### Added

- Added Roslyn source generator `PolyfillGenerator` that emits polyfill source files for missing language and runtime features.
- Added `IsExternalInit` polyfill to enable `init`-only property setters on frameworks older than .NET 5.
