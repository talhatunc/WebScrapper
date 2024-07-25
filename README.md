# WebScrapper

WebScrapper is an application that utilizes the WebView2 component to load a web page and allows you to select HTML elements to extract and view their data. It supports extracting `innerText`, `innerHTML`, or `outerHTML` of the selected elements and saves the extracted data.

## Features

- Load a web page and select HTML elements.
- Extract `innerText`, `innerHTML`, or `outerHTML` of the elements.
- Display extracted data in a `DataGridView`.
- Save and load tasks in JSON format for persistent data retrieval.

## Installation

1. Clone or download this repository.
2. Open the project in Visual Studio.
3. Install the required NuGet packages: `Microsoft.Web.WebView2`, `Newtonsoft.Json`.
4. Build and run the `WebScrapper` project.

## Usage

1. Enter a URL in the `TextBox`.
2. Click the `Go` button.
3. After the web page loads, hover over and click on the elements.
4. In the pop-up window, choose the action you want (`Extract Inner Text`, `Extract Inner HTML`, or `Extract Outer HTML`).
5. The results will be displayed in the `DataGridView` and saved in a JSON file.

## Contributing

If you would like to contribute to this project, please submit a pull request or open an issue.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
