import 'package:flutter/material.dart';
import 'features/example/presentation/screen/onboarding_1_screen.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      title: 'Onboarding Screen 1',
      debugShowCheckedModeBanner: false,
      home: OnBoardingScreen1(),
    );
  }
}
