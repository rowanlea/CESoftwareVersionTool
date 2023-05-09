# Cyber Essentials Gather Tool

Just a quick and crude application that parses the output of my Windows software version gathering script, or a Mac profile file.

Created for Codurance to help gather the information we need to achieve Cyber Essentials.

Feel free to use this tool to help your own company pass Cyber Essentials, or for any other reason you need to gather lists of software versions.

The output from this will give you every piece of software installed on the system, whether you've installed it yourself, or it's part of the OS.

## To do
- add the ability to read the JSON file output from the current process
- implement batch reading of data (all Windows files, Mac files, and JSON files)
- compiling batch information so I can output it in a more condense and readable format

## How to use
First generate the input it needs for your appropriate operating system (choose from below). After that you will have a file generated. You can take that file, and put it in the same directory as the executable this project builds to (for Windows), or just on your desktop (for Mac), and run the executable to generate a JSON file.

(the aim with the JSON file is to make it transportable for further use, when I've added the batch gathering and output there will be a nicer output you can directly use as an appendix).

### Getting Initial Windows File
1. Right click the WindowsSoftwareVersion.ps1 script in the repo.
2. Click on "run with powershell".
3. It might ask you about an execution policy change, you can just enter "n".
4. Enter your full name when prompted.
5. Give it a couple of minutes, and then you should have a file in the same location you ran the script from in the format: NAME#OPERATINGSYSTEM#VERSION.csv.

### Getting Initial Mac File
1. Click the apple button in the top left of your machine.
2. Click "about this mac".
3. On the overview screen click on the "System report..." button.
4. You now need to click/swipe onto a different app, and then go back to the system report (this is due to a bug on Macs). It will say "System Information" at the top right of your screen when done successfully.
5. Click on file on the bar at the top of your Mac, then click on save.
6. Save the document as your full name, and note where you save it to. It will be a ".spx" file.
