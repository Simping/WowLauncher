# WowLauncher

Game launcher for World of Warcraft private servers based on Cataclysm version 4.3.4.

## Features
* Set realmlist
* Clear cache
* Extract patched WoW client
* Download custom patch (detects whether user has the latest patch)
* Check server status
* Self update

## How to setup
1. Create news page, launcher version XML file, and file containing the patch sha1 hash (templates can be found in the misc folder or down below). Add these to your web server.
2. Enter your server info in Settings.cs
3. Create and add your server logo (PSD template in misc folder, use [Photopea](https://www.photopea.com/) if you don't have Photoshop)
4. Rename assembly name in the project properties to match your server name (optional)

### How to get sha1 hash
Open a command prompt and enter:
```console
CertUtil -hashfile [path_to_patch] sha1
```

### Templates
Launcher version XML file
```XML
<launcher>
	<version>1.0.0</version>
</launcher>
```

News page
```HTML
<html>
	<head>
		<style>
			body {
				background-color: black;
				color: gold;
				overflow: hidden;
			}
		</style>
	</head>
	<body>
		<ul>
			<li>this is simply an HTML page</li>
			<li>news 2</li>
			<li>news 3</li>
			<li>news 4</li>
		</ul>
	</body>
</html>
```