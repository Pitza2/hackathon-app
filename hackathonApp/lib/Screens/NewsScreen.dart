import 'package:flutter/material.dart';

class NewsScreen extends StatelessWidget {
  final List<String> newsItems = [
    '18:30 Dinner is ready at the cafeteria!',
    '13:50 Flutter workshop is starting in 10 minutes!',
    '10:30 Breakfast is ready at the cafeteria!',
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('News'),
        backgroundColor: Color(0xFF8739E5),
      ),
      body: Container(
        color: Color(0xFF1E003B),
        child: ListView.builder(
          itemCount: newsItems.length,
          itemBuilder: (context, index) {
            return Container(
                margin: EdgeInsets.all(10.0),
                padding: EdgeInsets.all(5.0),
                decoration: BoxDecoration(
                  color: Color(0xFF47009C),
                  borderRadius: BorderRadius.circular(10.0),
                ),
                child: Column(
                  mainAxisSize: MainAxisSize.min,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    Text(
                      newsItems[index],
                      style: TextStyle(
                        color: Colors.white,
                        fontSize: 18.0,
                      ),
                    ),
                    // Adds some spacing between the text and the image
                    Image.asset(
                      'assets/cat.jpeg',
                      fit: BoxFit.cover,
                    ),
                  ],
                )
                );
          },
        ),
      ),
    );
  }
}
