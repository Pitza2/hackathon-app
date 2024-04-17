import 'package:flutter/material.dart';

class IssueViewScreen extends StatelessWidget {
  String issueTitle = "issue";
  IssueViewScreen(String title){
    this.issueTitle=title.replaceAll(RegExp(r"[\[\]<>\']"), "");
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: const Color.fromARGB(255, 255, 255,255),
        body: Container(
          height: double.infinity,
          width: double.infinity,
          alignment: Alignment.centerLeft,
          margin: const EdgeInsets.only(
              top: 40, bottom: 300, left: 10, right: 10),
          padding: const EdgeInsets.all(10),
          decoration: BoxDecoration(
            color: const Color.fromRGBO(110, 103, 226,20).withOpacity(0.5),
            border: Border.all(color: Colors.white, width: 3),
            borderRadius: BorderRadius.circular(20.0),
          ),
          child: Text(
            style: TextStyle(color: Colors.white),
              issueTitle+"\n\n\nLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."),
        ));
  }
}