import 'package:flutter/cupertino.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:hackathon_app/Screens/HomeScreen.dart';
import 'package:hive/hive.dart';

class MentorInfoScreen extends StatefulWidget {
  @override
  State<MentorInfoScreen> createState() => _MentorInfoScreen();
}

class _MentorInfoScreen extends State<MentorInfoScreen> {
  final List<String> specializations = ['Web', 'Mobile', 'Embedded', 'Civic'];
  String dropdownValue='Web';
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
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Text(
              'Choose Specialization',
              style: TextStyle(
                fontSize: 24,
                color: Colors.white, // Text color
              ),
            ),
            SizedBox(height: 20),
            Container(
              margin: EdgeInsets.symmetric(horizontal: 10),
                child: DropdownButtonFormField<String>(
              icon: const Icon(Icons.keyboard_arrow_down_rounded),
              iconSize: 40,
              decoration: const InputDecoration(
                fillColor: Color(0xFF8739E5),
                filled: true,
                enabledBorder: OutlineInputBorder(
                  borderSide: BorderSide(
                    color: Colors.black38,
                    width: 2,
                  ),
                ),
              ),
              hint: const Text('Select your favourite fruit'),
              dropdownColor: Color(0xFF8739E5),
              value: dropdownValue,
              onChanged: (String? newValue) {
                setState(() {
                  dropdownValue = newValue!;
                }
                );
                Hive.box('data').put('spec',newValue);
                Hive.box('data').put('role','mentor');
                Navigator.of(context).push(MaterialPageRoute(builder: (context)=> const HomeScreen(title: '')));
              },
              items: specializations
                  .map<DropdownMenuItem<String>>((String value) {
                return DropdownMenuItem<String>(
                  value: value,
                  child: Text(
                    value,
                  ),
                );
              }).toList(),
            ))
          ],
        ),
      ),
    ));
  }
}
