// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
import * as vscode from 'vscode';

import { createFile } from './commands/create-file.command';
import { showFiles } from './commands/show-files.command';

// This method is called when your extension is activated
// Your extension is activated the very first time the command is executed
export function activate(context: vscode.ExtensionContext) {
  context.subscriptions.push(createFile('vscode-web-extension.createFile'));
  context.subscriptions.push(showFiles('vscode-web-extension.showFiles'));
}

// This method is called when your extension is deactivated
export function deactivate() { }
