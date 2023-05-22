import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'features/authentication/presentation/bloc/auth_bloc.dart';
import 'features/authentication/presentation/screen/Login_page.dart';
import 'features/feed/presentation/screen/home_page.dart';
import 'injection/injection.dart' as dependency_injection;
import 'injection/injection.dart';

void main() {
  dependency_injection.init();

  runApp(MultiBlocProvider(
    providers: [
      BlocProvider<AuthBloc>(create: (_) => serviceLocator<AuthBloc>(),)
    ],
    child: const MyApp()
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: LoginPage(),
    );
  }
}
