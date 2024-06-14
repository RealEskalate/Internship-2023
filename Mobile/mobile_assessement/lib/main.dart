import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'core/utils/colors.dart';
import 'features/issues/presentation/bloc/issues_bloc.dart';
import 'features/issues/presentation/screens/home.dart';
import 'injection.dart' as injection;

void main() {
  injection.init();
  runApp(MultiBlocProvider(providers: [
    BlocProvider<IssueBloc>(
      create: (_) => injection.sl<IssueBloc>(),
    ),
  ], child: const MyApp()));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
          primaryColor: primaryColor,
          scaffoldBackgroundColor: scaffoldBackground),
      title: 'Flutter Demo',
      debugShowCheckedModeBanner: false,
      home: Home(),
    );
  }
}
