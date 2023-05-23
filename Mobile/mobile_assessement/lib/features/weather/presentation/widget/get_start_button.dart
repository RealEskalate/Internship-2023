import 'package:flutter/material.dart';

class WelcomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: ElevatedButton(
          onPressed: () {
            // Handle button press
          },
          child: Text(
            'Get Started',
            style: TextStyle(fontSize: 16),
          ),
        ),
      ),
    );
  }
}