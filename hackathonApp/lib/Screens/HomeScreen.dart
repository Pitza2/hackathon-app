import 'package:flutter/material.dart';
import 'package:hackathon_app/Screens/IssueViewScreen.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key, required this.title});

  final String title;

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}
class IssueEntry extends StatelessWidget {
  String issueTitle = "issue";
  IssueEntry(Key? key):super(key:key);
  @override
  Widget build(BuildContext context) {

     return GestureDetector(
       onTap: (){
         Navigator.of(context).push(
             MaterialPageRoute(
               builder: (context) => IssueViewScreen(this.issueTitle+this.key.toString()),
             ));
       },
      child:  Container(
      height: 100,
      width: double.infinity,
      alignment: Alignment.centerLeft,
      margin: const EdgeInsets.all(20),
      padding: const EdgeInsets.only(left: 20),
      decoration: BoxDecoration(
        color: const Color.fromARGB(34,135, 57, 229),
        border: Border.all(color: Colors.black, width: 3),
        borderRadius: BorderRadius.circular(40.0),
      ),
      child: Text(issueTitle, style: TextStyle(fontSize: 40)),
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
        body: Center(
            child: Container(
              margin: EdgeInsets.only(top: 50,bottom: 10),
      child: ListView(
        children: issues,
      ),
    )));
  }
}
