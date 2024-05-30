import 'package:flutter/cupertino.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class MentorInfoScreen extends StatefulWidget {
  @override
  State<MentorInfoScreen> createState() => _MentorInfoScreen();
}

class _MentorInfoScreen extends State<MentorInfoScreen> {
  final items = ['One', 'Two', 'Three', 'Four'];
  String selectedValue = 'Four';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Register'),
        backgroundColor: Color(0xFF8739E5),
      ),
      backgroundColor: const Color(0xFF1E003B),
      body: SafeArea(
          child: Center(
              child: Column(
                  mainAxisSize: MainAxisSize.min,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
            const Text(
              'Choose your specialization',
              style: TextStyle(
                color: Colors.white,
                fontSize: 18.0,
              ),
            ),
            const SizedBox(height: 30.0),
            Container(
                margin: EdgeInsets.symmetric(horizontal: 20),
                decoration: BoxDecoration(
                    color: Color(0xFFFF8359),
                    borderRadius: BorderRadius.circular(10)),

                // dropdown below..
                child: Expanded(
                  child: DropdownButton<String>(
                    value: selectedValue,
                    onChanged: (newValue) =>
                        setState(() => selectedValue = newValue!),
                    items: items
                        .map<DropdownMenuItem<String>>(
                            (String value) => DropdownMenuItem<String>(
                                  value: value,
                                  child: Text(value),
                                ))
                        .toList(),

                    // add extra sugar..
                    icon: Icon(Icons.arrow_drop_down),
                    iconSize: 42,
                    underline: SizedBox(),
                  ),
                ))
          ]))),
    );
  }
}
