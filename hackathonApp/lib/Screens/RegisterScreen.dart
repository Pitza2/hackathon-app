import 'package:flutter/material.dart';

import 'HomeScreen.dart';

class LogInScreen extends StatefulWidget {
  const LogInScreen({super.key, required this.title});

  final String title;


  @override
  State<LogInScreen> createState() => _LogInScreenState();
}

class _LogInScreenState extends State<LogInScreen> {
  int _counter = 0;

  void _incrementCounter() {
    setState(() {

      _counter++;
    });
  }

  @override
  Widget build(BuildContext context) {
    final String username="partisipant";
    final String password="parola01";
    final Size screenSize=MediaQuery.of(context).size;
    final TextEditingController usernameController=TextEditingController();
    final TextEditingController passwordController=TextEditingController();
    return Scaffold(
      appBar: AppBar(

        backgroundColor: Theme.of(context).colorScheme.inversePrimary,

        title: Text(widget.title),
      ),
      body: Center(
          child: Container(
              padding: const EdgeInsets.all(20.0),
              width: screenSize.width,
              height: screenSize.height * 0.3,
              decoration: BoxDecoration(
                color: const Color.fromARGB(34,135, 57, 229),
                borderRadius: BorderRadius.circular(20.0),
              ),
              child: Center(

                child: Column(

                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: <Widget>[
                    TextFormField(
                      controller: usernameController,
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Enter your username',
                      ),
                    ),
                    TextFormField(
                      controller: passwordController,
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: 'Enter your password',
                      ),
                      onFieldSubmitted: (text){
                        if(usernameController.text==username && passwordController.text == password){
                          // showDialog(context: context, builder:
                          // (BuildContext context){
                          //   return AlertDialog(
                          //     title: new Text("lolo"),
                          //     content: new Text("parola ok"),
                          //   );
                          // }
                          // );
                          Navigator.of(context).push(
                              MaterialPageRoute(
                                builder: (context) => const HomeScreen(title: '',),
                              )
                          );
                        }
                        else{
                          showDialog(context: context, builder:
                              (BuildContext context){
                            return AlertDialog(
                              title: new Text("lolo"),
                              content: new Text("parola not ok"),
                            );
                          }
                          );
                        }
                    },
                      obscureText: true,
                    ),
                  ],
                ),
              ))),
      floatingActionButton: FloatingActionButton(
        onPressed: _incrementCounter,
        tooltip: 'Increment',
        child: const Icon(Icons.add),
      ), // This trailing comma makes auto-formatting nicer for build methods.
    );
  }
}
