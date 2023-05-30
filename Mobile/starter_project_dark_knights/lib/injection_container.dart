import 'package:dark_knights/article_injection_container.dart';
import 'package:dark_knights/feed_injection_container.dart';
import 'package:get_it/get_it.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import 'user_injection_container.dart';

final sl = GetIt.instance;

Future<void> init() async {
  //! Features - User
  await userInjectionInit();

  //! Features - Article
  await articleInjectionInit();

  //! Features - Feed
  await feedInjectionInit();

  //! Core

  //! External
  final sharedPreferences = SharedPreferences.getInstance();
  sl.registerLazySingletonAsync(() => sharedPreferences);
  await GetIt.instance.isReady<SharedPreferences>();
  sl.registerLazySingleton(() => http.Client());
}
