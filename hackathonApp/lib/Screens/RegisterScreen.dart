import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:hackathon_app/Screens/LogInScreen.dart';
import 'package:hackathon_app/Screens/MentorInfoScreen.dart';
import 'package:hive/hive.dart';

class RegisterScreen extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final TextEditingController usernameController = TextEditingController();
    final TextEditingController passwordController = TextEditingController();
    final TextEditingController mentorKeyController = TextEditingController();
    void tryLogin([String text = ""]) {
      if (mentorKeyController.text.isEmpty) {
        Hive.box('data').put('spec', '');
        Hive.box('data').put('role', 'participant');
        Navigator.of(context).push(MaterialPageRoute(
          builder: (context) => const LogInScreen(
            title: '',
          ),
        ));
      } else if (mentorKeyController.text == "mentorUni") {
        Navigator.of(context).push(MaterialPageRoute(
          builder: (context) => MentorInfoScreen(),
        ));
      } else {
        showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(
                title: new Text("lolo"),
                content: new Text("mentor key wrong"),
              );
            });
      }
    }

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
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              const Text(
                'HackHelp',
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 32.0,
                  fontWeight: FontWeight.bold,
                ),
              ),
              const SizedBox(height: 30.0),
              TextField(
                controller: usernameController,
                style: const TextStyle(color: Colors.white),
                decoration: InputDecoration(
                  hintText: 'Email',
                  hintStyle: const TextStyle(color: Colors.white54),
                  filled: true,
                  fillColor: const Color(0xFF8739E5),
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(12.0),
                    borderSide: BorderSide.none,
                  ),
                  contentPadding: const EdgeInsets.all(16.0),
                ),
              ),
              const SizedBox(height: 20.0),
              TextField(
                controller: passwordController,
                style: const TextStyle(color: Colors.white),
                obscureText: true,
                decoration: InputDecoration(
                  hintText: 'Password',
                  hintStyle: const TextStyle(color: Colors.white54),
                  filled: true,
                  fillColor: const Color(0xFF47009C),
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(12.0),
                    borderSide: BorderSide.none,
                  ),
                  contentPadding: const EdgeInsets.all(16.0),
                ),
              ),
              const SizedBox(height: 20.0),
              TextField(
                controller: mentorKeyController,
                style: const TextStyle(color: Colors.white),
                obscureText: true,
                decoration: InputDecoration(
                  hintText: 'mentor key',
                  hintStyle: const TextStyle(color: Colors.white54),
                  filled: true,
                  fillColor: const Color(0xFF47009C),
                  border: OutlineInputBorder(
                    borderRadius: BorderRadius.circular(12.0),
                    borderSide: BorderSide.none,
                  ),
                  contentPadding: const EdgeInsets.all(16.0),
                ),
              ),
              const SizedBox(height: 20.0),
              SizedBox(
                width: double.infinity,
                height: 50.0,
                child: ElevatedButton(
                  style: const ButtonStyle(
                      padding: MaterialStatePropertyAll<EdgeInsets>(
                          EdgeInsets.symmetric(horizontal: 16, vertical: 12)),
                      backgroundColor:
                          MaterialStatePropertyAll<Color>(Color(0xFFFF8359))),
                  onPressed: tryLogin,
                  child: const Text(
                    'Register',
                    style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    ));
  }
}
