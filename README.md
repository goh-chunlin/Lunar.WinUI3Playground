# Lunar.WinUI3Playground

<div align="center">
    <img src="https://gclstorage.blob.core.windows.net/images/Lunar.WinUI3Playground-banner.png" />
</div>

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)
[![Donate](https://img.shields.io/badge/$-donate-ff69b4.svg)](https://www.buymeacoffee.com/chunlin)

A desktop application built in WinUI 3 for personal learning purpose.

## Local Development and Use ##
1. Checkout the codes to a working directory;
2. Create a file `appsettings.json` with the following entries: \
   ```
   {
   "TwitterConfig": {
         "ConsumerApiKey": "...",
         "ConsumerApiSecret": "...",
         "AccessToken": "...",
         "AccessTokenSecret": "..."
      }
   }
   ```
3. The values for the entries above can be gotten from [Twitter Developer Portal](https://developer.twitter.com/en/portal/projects-and-apps). You have to create a **Standalone App**;
4. Run the program with **Lunar.WinUI3Playground (Package)** as startup project on Visual Studio 2022.

## Demo ##

<img src="https://gclstorage.blob.core.windows.net/images/Lunar.WinUI3Playground-animation.gif" />

## Blog Post ##

Read more at [WinUI 3 Learning Notes](https://cuteprogramming.wordpress.com/2022/01/31/winui-3-learning-notes/).

## License ##

This library is distributed under the GPL-3.0 License found in the [LICENSE](./LICENSE) file.