import 'package:flutter/material.dart';

import 'features/city/presentation/screen/splash_screen.dart';
// import 'package:matador/core/utils/constants/global_variables.dart';
// import 'package:matador/features/auth/presentation/screen/login_page.dart';
import 'features/city/injectory.dart' as di;

void main() {
  di.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Login Page',
      home: SplashScreen(),
    );
  }
}
