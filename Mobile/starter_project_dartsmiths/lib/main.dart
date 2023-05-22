import 'package:dartsmiths/features/article/presentation/bloc/article_bloc.dart';
import 'package:dartsmiths/features/article/presentation/screens/article_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import 'features/feed/presentation/screen/home_page.dart';
import 'package:dartsmiths/injection/injection.dart' as injection;

import 'injection/article_injection.dart';

void main() {
  injection.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
        providers: [
          BlocProvider<ArticleBloc>(
            create: (context) => sl<ArticleBloc>()..add(GetArticleEvent(id: '1234')),
          ),
        ],
        child: MaterialApp(
          debugShowCheckedModeBanner: false,
          title: 'Flutter Demo',
          theme: ThemeData(
            primarySwatch: Colors.blue,
          ),
          home: ArticleReading(),
        ));
  }
}
