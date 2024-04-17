import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

import 'HomeScreen.dart';

class LogInScreen extends StatefulWidget {
  const LogInScreen({super.key, required this.title});

  final String title;

  @override
  State<LogInScreen> createState() => _LogInScreenState();
}

class _LogInScreenState extends State<LogInScreen> {
  @override
  Widget build(BuildContext context) {
    final String username = "partisipant";
    final String password = "parola01";
    final Size screenSize = MediaQuery.of(context).size;
    final TextEditingController usernameController = TextEditingController();
    final TextEditingController passwordController = TextEditingController();
    void tryLogin([String text = ""]) {
      if (usernameController.text == username &&
          passwordController.text == password) {
        Navigator.of(context).push(MaterialPageRoute(
          builder: (context) => const HomeScreen(
            title: '',
          ),
        ));
      } else {
        showDialog(
            context: context,
            builder: (BuildContext context) {
              return AlertDialog(
                title: new Text("lolo"),
                content: new Text("parola not ok"),
              );
            });
      }
    }

    return Scaffold(
      backgroundColor: const Color.fromRGBO(180, 57, 229, 34),
      body: Center(
          child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceEvenly,
        children: [
          Text(
            "HackHelp",
            style: TextStyle(color: Colors.white, fontSize: 70),
          ),
          Container(

              height: 200,
              width: double.infinity,
              padding: EdgeInsets.symmetric(horizontal: 30,vertical: 10),
              decoration: BoxDecoration(
                color: const Color.fromRGBO(180, 106, 75, 100).withOpacity(0.1),
              ),
              child: Center(
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: <Widget>[
                    TextFormField(
                      controller: usernameController,
                      style: TextStyle(color: Colors.white),
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        floatingLabelStyle: TextStyle(color: Colors.white),
                        labelStyle: TextStyle(color: Colors.white),
                        labelText: 'Enter your username',
                      ),
                    ),
                    TextFormField(
                      controller: passwordController,
                      style: TextStyle(color: Colors.white),
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        floatingLabelStyle: TextStyle(color: Colors.white),
                        labelStyle: TextStyle(color: Colors.white),
                        labelText: 'Enter Password',
                      ),
                      onFieldSubmitted: tryLogin,
                      obscureText: true,
                    ),
                  ],
                ),
              )),
          ElevatedButton(
            onPressed: tryLogin,
            child: Text("LogIn", style: TextStyle(color: Colors.white)),
            style: ButtonStyle(
                padding: MaterialStatePropertyAll<EdgeInsets>(
                    EdgeInsets.symmetric(horizontal: 40, vertical: 20)),
                backgroundColor: MaterialStatePropertyAll<Color>(
                    Color.fromARGB(255, 255, 131, 89))),
          )
        ],
      )),
    );
  }
}
