import 'package:flutter/material.dart';
import 'package:hackathon_app/Screens/NewsScreen.dart';

class IssueViewScreen extends StatelessWidget {
  String issueTitle = "issue";
  IssueViewScreen(String title){
    this.issueTitle=title.replaceAll(RegExp(r"[\[\]<>\']"), "");
  }
  final TextEditingController _textEditingController = TextEditingController(text:'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.');

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFF1E003B),
      appBar: AppBar(
        backgroundColor: const Color(0xFF1E003B),
        title: Text(this.issueTitle, style: TextStyle(color: Colors.white),),
      ),
      body: Padding(
        padding: EdgeInsets.only(bottom: MediaQuery.of(context).size.height*0.2,left: 20.0,right: 20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Expanded(
              child: Container(
                decoration: BoxDecoration(
                  color: const Color(0xFF8739E5),
                  border: Border.all(color: Colors.grey),
                  borderRadius: BorderRadius.circular(8.0),
                ),
                child: Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 12.0),
                  child: TextFormField(
                    enabled: true,
                    style: TextStyle(color: Colors.white),
                    controller: _textEditingController,
                    maxLines: null, // Allows multiline input
                    decoration: const InputDecoration(
                      border: InputBorder.none,
                      hintText: 'Type your text here...',
                    ),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),bottomNavigationBar: BottomAppBar(
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
              ),//0xFFFFDF40
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
              ),//0xFFFFDF40
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
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          // Handle save button press
          String enteredText = _textEditingController.text;
          print('Text saved: $enteredText');
          // You can add further logic here to save the text
        },
        child: Icon(Icons.save),
      ),
      floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
    );
  }
}