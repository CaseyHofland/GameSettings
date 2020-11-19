# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.1.1] - 2020-11-19
### Added
- Undo functionality for every base Setting.
- Min max values for IntSetting and FloatSetting. If both of these are set, the inspector reflects this with a slider.
- Useful hints added to certain Setting Editors that could use it.
- Quality Settings from A to R.

### Removed
- FullScreenModeSetting wasn't a reliable setting to change. Instead, use FullScreenSetting.

### Fixed
- A typo in SettingsStartupLoader. setingsToLoadOnStartup = settingsToLoadOnStartup.