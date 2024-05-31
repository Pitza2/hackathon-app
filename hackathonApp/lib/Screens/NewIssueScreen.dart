import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:hackathon_app/HiveManager.dart';
import 'package:hackathon_app/Screens/IssueData.dart';
import 'package:hive/hive.dart';

class NewIssueScreen extends StatefulWidget {
  @override
  _NewIssueScreen createState() => _NewIssueScreen();
}

class _NewIssueScreen extends State<NewIssueScreen> {
  String dropdownValue='Web';
  final TextEditingController titleController = TextEditingController();
  final TextEditingController descriptionController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Container(
        decoration: const BoxDecoration(
        gradient: LinearGradient(
        stops: [0, 0.6, 0.86],
        begin: Alignment.bottomRight,
        end: Alignment.topLeft,
        colors: [
        Color(0xFFFF8359),
    Color(0xFF47009C),
    Color(0xFF1E003B)
    ])),
    child: Scaffold(
      backgroundColor: Colors.transparent,
      appBar: AppBar(
        backgroundColor: const Color(0xFF1E003B),
        title: const Text('Category and Description', style: TextStyle(color: Colors.white),),
      ),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            const Text(
              'Pick a Category:',
              style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.bold,
                color: Colors.white
              ),
            ),
            Container(
              color: Colors.transparent,
                margin: EdgeInsets.symmetric(horizontal: 10),
                child: DropdownButtonFormField<String>(
                  icon: const Icon(Icons.keyboard_arrow_down_rounded),
                  iconSize: 40,
                  decoration: const InputDecoration(
                    fillColor: Color(0xFF8739E5),
                    filled: true,
                    enabledBorder: OutlineInputBorder(
                      borderSide: BorderSide(
                        color: Colors.white,
                        width: 2,
                      ),
                    ),
                  ),
                  hint: const Text('select type of issue',style: TextStyle(color: Colors.white),),
                  dropdownColor: Color(0xFF8739E5),
                  value: dropdownValue,
                  onChanged: (String? newValue) {
                    setState(() {
                      dropdownValue = newValue!;
                    }
                    );
                    Hive.box('data').put('spec',newValue);
                  },
                  items: Hive.box('data').get('specList')
                      .map<DropdownMenuItem<String>>((String value) {
                    return DropdownMenuItem<String>(
                      value: value,
                      child: Text(
                        value,
                      ),
                    );
                  }).toList(),
                )),
            const SizedBox(height: 20),
            TextFormField(
              controller: titleController,
              style: const TextStyle(color: Colors.white),
              decoration: const InputDecoration(
                hintStyle: const TextStyle(color: Colors.white54),
                hintText: 'Enter title',
                border: OutlineInputBorder(),
              ),
              maxLines: 1,
              maxLength: 20,
            ),
            const SizedBox(height: 20),
            TextFormField(
              controller: descriptionController,
              style: const TextStyle(color: Colors.white),
              decoration: const InputDecoration(
                hintStyle: const TextStyle(color: Colors.white54),
                hintText: 'Enter description (10-50 words)',
                border: OutlineInputBorder(),
              ),
              maxLines: 3,
            ),
            const SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                HiveManager.instance.issueBox.add(IssueData(titleController.text, descriptionController.text, dropdownValue));
                Navigator.pop(context);
                  },
              style: const ButtonStyle(
                backgroundColor: MaterialStatePropertyAll<Color>(
                    Color(0xFFFF8359))),
              child: const Text('Submit',style: TextStyle(color: Colors.white),),
            ),
          ],
        ),
      ),
    ));
  }
}