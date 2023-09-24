import { commands, Uri, window, workspace } from "vscode";

export const createFile = (name: string) => commands.registerCommand(name, async () => {
  const folder = await window.showWorkspaceFolderPick();
  if (!folder) {
    window.showInformationMessage('Not found!');
    return;
  }

  const decoder = new TextDecoder();
  const encoder = new TextEncoder();

  const uri = Uri.joinPath(folder.uri, 'sample.txt');
  const newContent = encoder.encode('Auto created!');
  await workspace.fs.writeFile(uri, newContent);

  const content = await workspace.fs.readFile(uri);
  console.log(decoder.decode(content));
});
