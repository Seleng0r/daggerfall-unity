// Put your file to "YOUR_UNITY_PROJ/Assets/StreamingAssets"
// example: "YOUR_UNITY_PROJ/Assets/StreamingAssets/db.bytes"

string dbPath = "";

if (Application.platform == RuntimePlatform.Android)
{
  // Android
  string oriPath = System.IO.Path.Combine(Application.streamingAssetsPath, "db.bytes");
  
  // Android only use WWW to read file
  WWW reader = new WWW(oriPath);
  while ( ! reader.isDone) {}
  
  realPath = Application.persistentDataPath + "/db";
  System.IO.File.WriteAllBytes(realPath, reader.bytes);
  
  dbPath = realPath;
}
else
{
  // iOS
  dbPath = System.IO.Path.Combine(Application.streamingAssetsPath, "db.bytes");
}