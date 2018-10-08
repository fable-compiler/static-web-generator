/// @ts-check
const path = require("path");

function resolve(filePath) {
  return path.resolve(__dirname, filePath)
}

function runScript(scriptPath) {
  try {
      console.log("Running script")
      var childProcess = require("child_process");
      var path = require("path");
      var cp = childProcess.fork(scriptPath);
      cp.on("exit", function (code, signal) {
          if (code === 0) {
              console.log("Success");
          } else {
              console.log("Exit", { code: code, signal: signal });
          }
      });
      cp.on("error", console.error.bind(console));
  } catch (err) {
      console.error(err);
  }
}

var babelOptions = {
    presets: [
        ["@babel/preset-env", {
            "targets": {
                "node": "current"
            }
        }]
    ],
    plugins: ["@babel/plugin-transform-modules-commonjs"]
};

var outFile = resolve("build/Main.js");

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("[Environment]: " + (isProduction ? "production" : "development"));

module.exports = {
  entry: resolve("src/Fable.StaticPageGenerator.fsproj"),
  outDir: path.dirname(outFile),
  babel: babelOptions,
  fable: { define: isProduction ? [] : ["DEBUG"], },
  postbuild() { runScript(outFile) }
};
