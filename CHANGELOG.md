# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [0.2.0-pre] - 2021-05-16
### Changed
- Rewrote the base settings and editors to make use of generic serialization. No more objectValue variables just to get the serialization to work!
- Changed the minimal Unity version to 2020.1 for the generic serialization support.

### Removed
- Min max values for IntSetting and FloatSetting removed. If a slider is required, one can add attributes to settings via this trick: [NonSerialized] [Range(0, 1)] private float serializedValue; This will be documentated for users at a later date.
- Any useful Editors for special settings removed. These may be added back in later as attributes.
- SettingsStartupLoader removed. The solution will be reworked at a later date (or return if no better solution is found).
- UI Interpreters removed. This has been uncoupled into a standalone package called [UIWitches](https://github.com/Casey-Hofland/UIWitches) (com.caseydecoder.uiwitches). Integration support with this package is coming (at a later date).

## [0.1.1] - 2020-11-19
### Added
- Undo functionality for every base Setting.
- Min max values for IntSetting and FloatSetting. If both of these are set, the inspector reflects this with a slider.
- Useful hints added to certain Setting Editors that could use it.
- Quality Settings Implementations.

### Removed
- FullScreenModeSetting wasn't a reliable setting to change. Instead, use FullScreenSetting.

### Fixed
- A typo in SettingsStartupLoader. setingsToLoadOnStartup = settingsToLoadOnStartup.