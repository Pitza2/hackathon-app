import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class NewIssueScreen extends StatefulWidget {
  @override
  _NewIssueScreen createState() => _NewIssueScreen();
}

class _NewIssueScreen extends State<NewIssueScreen> {
  String selectedCategory = 'Category 1';
  String description = '';
  List<String> categories = ['Category 1', 'Category 2', 'Category 3'];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Category and Description'),
      ),
      body: Padding(
        padding: EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Text(
              'Pick a Category:',
              style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.bold,
              ),
            ),
            DropdownButton<String>(
              value: selectedCategory,
              onChanged: (newValue) {
                setState(() {
                  selectedCategory = newValue!;
                });
              },
              items: categories.map((String value) {
                return DropdownMenuItem<String>(
                  value: value,
                  child: Text(value),
                );
              }).toList(),
            ),
            SizedBox(height: 20),
            TextField(
              decoration: InputDecoration(
                hintText: 'Enter description (10-50 words)',
                border: OutlineInputBorder(),
              ),
              maxLines: 3,
              onChanged: (value) {
                setState(() {
                  description = value;
                });
              },
            ),
            SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                // Validate description length
                if (description.trim().split(' ').length < 10 ||
                    description.trim().split(' ').length > 50) {
                  showDialog(
                    context: context,
                    builder: (BuildContext context) {
                      return AlertDialog(
                        title: Text('Invalid Description'),
                        content: Text('Description must be between 10 and 50 words.'),
                        actions: [
                          TextButton(
                            onPressed: () {
                              Navigator.of(context).pop();
                            },
                            child: Text('OK'),
                          ),
                        ],
                      );
                    },
                  );
                } else {
                  // Process the category and description
                  print('Selected Category: $selectedCategory');
                  print('Description: $description');
                }
              },
              child: Text('Submit'),
            ),
          ],
        ),
      ),
    );
  }
}