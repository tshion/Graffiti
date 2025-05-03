import { readdirSync, readFileSync } from "node:fs";
import { join } from "node:path";
import ts from "typescript";


const targetFilePath = join(__dirname, "..", "data-sample.ts");

// types/ の解析
const typeDirPath = join(__dirname, "..", "types");
const typeFilePaths = readdirSync(typeDirPath)
  .filter(filename => filename.endsWith(".ts"))
  .map(filename => join(typeDirPath, filename));
[...typeFilePaths].forEach(fileName => {
  const sourceFile = ts.createSourceFile(
    fileName,
    readFileSync(fileName).toString(),
    ts.ScriptTarget.ES2015,
      /*setParentNodes */ true
  );
  ts.forEachChild(sourceFile, node => {
    if (ts.isTypeAliasDeclaration(node)) {
      console.log(`${node.name.escapedText}: ${node.type.getText()}`);
    }
  });
});

// データ定義の解析
const sourceFile = ts.createSourceFile(
  targetFilePath,
  readFileSync(targetFilePath).toString(),
  ts.ScriptTarget.ES2015,
      /*setParentNodes */ true
);
ts.forEachChild(sourceFile, node => {
  if (ts.isImportDeclaration(node)) {
    console.log(node.getText());
  } else if (ts.isClassDeclaration(node)) {
    console.log(node.name?.escapedText);
  }
});
