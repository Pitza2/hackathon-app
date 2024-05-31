import 'package:flutter/material.dart';
import 'package:hackathon_app/HiveManager.dart';
import 'package:hackathon_app/Screens/HomeScreen.dart';
import 'package:hive/hive.dart';
import 'package:hive_flutter/hive_flutter.dart';

import 'Screens/IssueData.dart';
import 'Screens/LogInScreen.dart';

Future<void> main() async {
  WidgetsFlutterBinding.ensureInitialized();
  // To intialise the hive database
  await Hive.initFlutter();
  await HiveManager.instance.initHiveManager();
  var box= await Hive.openBox('data');
  final List<String> specializations = ['Web', 'Mobile', 'Embedded', 'Civic'];
  Hive.box('data').put('specList',specializations);
  final List<IssueData> Issues = [
    IssueData('Issue 1', 'webwebweb', 'Web'),
    IssueData('Issue 2', 'webwebweb2', 'Web'),
    IssueData('Issue 3', 'webwebweb3', 'Web'),
    IssueData('Issue 1', 'mobilemobilemobilemobile ', 'Mobile'),
    IssueData('Issue 2', 'mobilemobilemobilemobile 2', 'Mobile'),
    IssueData('Issue 3', 'mobilemobilemobilemobile 3', 'Mobile'),
    IssueData('Issue 1', 'EmbeddedEmbeddedEmbedded 1', 'Embedded'),
    IssueData('Issue 2', 'EmbeddedEmbeddedEmbedded 2', 'Embedded'),
    IssueData('Issue 3', 'EmbEmbeddedEmbeddedEmbedded 3', 'Embedded'),
    IssueData('Issue 1', 'CivicCivicCivic 1', 'Civic'),
    IssueData('Issue 2', 'CivicCivicCivic 2', 'Civic'),
    IssueData('Issue 3', 'CivicCivicCivic 3', 'Civic'),
    ];
  for(int i=0;i<Issues.length;i++){
    HiveManager.instance.issueBox.add(Issues[i]);
  }

  runApp(const MyApp());

}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {

    return MaterialApp(
      title: 'HackHelp',
      routes: {
        '/home': (context) => HomeScreen(title: 'Home'),
      },
      theme: ThemeData(
        
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.deepPurple),
        useMaterial3: true,
      ),
      home: const LogInScreen(title: 'HackHelp'),
    );
  }
}