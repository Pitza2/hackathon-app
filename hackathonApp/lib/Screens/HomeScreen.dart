import 'package:flutter/material.dart';
import 'package:hackathon_app/Screens/IssueViewScreen.dart';

import 'NewsScreen.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key, required this.title});

  final String title;

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class IssueEntry extends StatelessWidget {
  String issueTitle = "issue";

  IssueEntry(Key? key) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
        onTap: () {
          Navigator.of(context).push(MaterialPageRoute(
            builder: (context) =>
                IssueViewScreen(this.issueTitle + this.key.toString()),
          ));
        },
        child: Container(
          margin: const EdgeInsets.only(bottom: 10),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.start,
            children: [
              Container(
                padding: const EdgeInsets.all(10),
                decoration: BoxDecoration(
                    color: const Color.fromRGBO(110, 103, 226, 20)
                        .withOpacity(0.5),
                    border: Border.all(color: Colors.white, width: 3),
                    shape: BoxShape.circle),
                child: Text(
                  key.toString().replaceAll(RegExp(r"[\[\]\<\>\']"), ""),
                  style: const TextStyle(fontSize: 20, color: Colors.white),
                ),
              ),
              Expanded(
                  child: Container(
                height: 50,
                alignment: Alignment.centerLeft,
                padding: const EdgeInsets.only(left: 20),
                decoration: BoxDecoration(
                  color:
                      const Color.fromRGBO(110, 103, 226, 20).withOpacity(0.5),
                  border: Border.all(color: Colors.white, width: 3),
                  borderRadius: BorderRadius.circular(40.0),
                ),
                child: Text(issueTitle,
                    style: const TextStyle(fontSize: 20, color: Colors.white)),
              ))
            ],
          ),
        ));
  }
}

class _HomeScreenState extends State<HomeScreen> {
//const Color.fromARGB(34, 255, 101, 255)
  List<IssueEntry> issues = [
    IssueEntry(const Key("1")),
    IssueEntry(const Key("2")),
    IssueEntry(const Key("3")),
    IssueEntry(const Key("4")),
    IssueEntry(const Key("5")),
    IssueEntry(const Key("6")),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFF1E003B),
      appBar: AppBar(
        title: const Text('Issues Page'),
        backgroundColor: const Color(0xFF8739E5),
      ),
      body: Center(
          child: Container(
        margin: const EdgeInsets.only(top: 50, bottom: 10),
        child: ListView(
          children: issues,
        ),
      )),
      bottomNavigationBar: BottomAppBar(
        color: const Color(0xFF47009C),
        child: Padding(
            padding: const EdgeInsets.symmetric(horizontal: 0, vertical: 3.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              mainAxisSize: MainAxisSize.max,
              children: [
                ElevatedButton(
                  style: const ButtonStyle(
                      backgroundColor: MaterialStatePropertyAll<Color>(
                          Color(0xFFFF8359))
                  ),
                  onPressed: () {
                    // Add issue functionality
                    print('Add Issue');
                  },
                  child: const Text(
                    'Add Issue',
                    style: TextStyle(color: Colors.white),
                  ),
                ),
                ElevatedButton(
                  style: const ButtonStyle(
                      backgroundColor: MaterialStatePropertyAll<Color>(
                          Color(0xFFFF8359))
                  ),
                  onPressed: () {
                    Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) =>  NewsScreen(),
                    ));
                  },
                  child: const Text(
                    'News',
                    style: TextStyle(color: Colors.white),
                  ),
                ),
                ElevatedButton(
                  style: const ButtonStyle(
                      backgroundColor: MaterialStatePropertyAll<Color>(
                          Color(0xFFFF8359))
                  ),
                  onPressed: () {
                    // Navigate to my issues functionality
                    print('My Issues');
                  },
                  child: const Text(
                    'My Issues',
                    style: TextStyle(color: Colors.white),
                  ),
                ),
              ],
            )),
      ),
    );
  }
}
