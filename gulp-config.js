module.exports = function () {
  var instanceRoot = "E:\\inetpub\\wwwroot\\marketing-village";
  var config = {
    websiteRoot: instanceRoot + "\\Website",
    sitecoreLibraries: instanceRoot + "\\Website\\bin",
    licensePath: instanceRoot + "\\Data\\license.xml",
    solutionName: "MarketingVillage",
    buildConfiguration: "Debug",
    runCleanBuilds: false
  };
  return config;
}