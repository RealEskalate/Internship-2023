import 'package:flutter/material.dart';
import 'package:mobile_assessement/features/get_started/presentation/screen/get_started_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Weatherify',
      home: const getStartedPage(),
    );
  }
}
