import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'features/city/injectory.dart';
import 'features/city/presentation/bloc/search/seach_bloc.dart';
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
    return MultiBlocProvider(
      providers: [
        BlocProvider<SearchBloc>(
          create: (_) => sl<SearchBloc>(),
        ),
        // Add more BlocProviders here if needed
      ],
      child: MaterialApp(
        title: 'Flutter Demo',
        theme: ThemeData(
          primarySwatch: Colors.blue,
        ),
        home: SplashScreen(),
      ),
    );
  }
}
