import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/weatherify/presentation/screen/welcome_page.dart';

import 'injection/injection.dart';

void main() {
  init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home:WelcomePage(),
      
    );
  }
}
