/// @ts-check
const path = require("path");

function resolve(filePath) {
  return path.resolve(__dirname, filePath)
}

module.exports = {
  entry: resolve("src/Fable.StaticPageGenerator.fsproj"),
  outDir: resolve("build"),
  babel: { plugins: ["transform-es2015-modules-commonjs"] },
  fable: { define: ["DEBUG"] },
  postbuild() {
    var buildDir = resolve("build");
    Object.keys(require.cache).forEach(function(key) {
      if (key.startsWith(buildDir))
        delete require.cache[key]
    })
    require(resolve("build/Main.js"));
  }
};
