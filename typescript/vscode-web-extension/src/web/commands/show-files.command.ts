import { commands, FileType, window, workspace } from 'vscode';

export const showFiles = (name: string) => commands.registerCommand(name, async () => {
  const folder = await window.showWorkspaceFolderPick();
  if (!folder) {
    window.showInformationMessage('Not found!');
    return;
  }

  const dirs = await workspace.fs.readDirectory(folder.uri);
  dirs
    .filter(([_, fileType]) => fileType === FileType.File)
    .forEach(([path, _], index) => console.log(`${index}: ${path}`));
});
