import 'package:flutter/material.dart';
import 'package:mobile_assessement/presentation/screen/detail.dart';
import 'package:mobile_assessement/presentation/screen/get_started.dart';

import 'injection.dart';
import 'presentation/screen/home_page.dart';

void main() {
  setupLocator();
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Home Page',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: GetStartedScreen(),
    );
  }
}
