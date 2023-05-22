import 'package:dark_knights/features/article/presentation/bloc/article_bloc.dart';
import 'package:dark_knights/features/article/presentation/screen/article_reading_page.dart';
import 'package:dark_knights/features/user_profile/presentation/bloc/user_profile_bloc.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:get_it/get_it.dart';
import 'features/splash_screen/presentation/screen/splash_screen.dart';
import 'injection_container.dart' as di;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await di.init();
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  static GetIt get sl => GetIt.instance;
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
        providers: [
          BlocProvider<ArticleBloc>(
            create: (_) => di.sl<ArticleBloc>(),
          ),
          BlocProvider<UserProfileBloc>(
            create: (_) => di.sl<UserProfileBloc>(),
          )
        ],
        child: MaterialApp(
          title: 'Flutter Demo',
          theme: ThemeData(
            primarySwatch: Colors.blue,
          ),
          home: const ArticleReadingPage(article_id: "1"),
        ));
  }
}
