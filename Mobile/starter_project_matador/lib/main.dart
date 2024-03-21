import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/global_variables.dart';
import 'package:matador/features/auth/presentation/screen/login_page.dart';
import 'injection/injection.dart' as di;

void main() {
  di.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Login Page',
      theme: ThemeData(
        primaryColor: primaryColor,
      ),
      home: const LoginPage(),
    );
  }
}
