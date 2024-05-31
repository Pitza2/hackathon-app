import 'package:hive/hive.dart';

import 'Screens/IssueData.dart';

class HiveManager{
  late Box<IssueData> issueBox;
  static final HiveManager instance = HiveManager._internal();

  factory HiveManager() => instance;
  HiveManager._internal();

  Future<void> initHiveManager() async {
    Hive.registerAdapter(IssueDataAdapter());
    issueBox = await Hive.openBox<IssueData>('issues');
  }
}