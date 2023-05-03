import 'package:flutter/material.dart';
import 'features/onboarding/presentation/screen/onboarding_screen.dart';
import 'features/feed/presentation/screen/home_page.dart';

import 'features/login_page/Presentation/screen/login_page.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Login Page',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const HomePage(),
    );
  }
}
