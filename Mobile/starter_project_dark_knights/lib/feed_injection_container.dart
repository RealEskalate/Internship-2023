import 'package:dark_knights/features/feeds/data/datasources/feed_remote_data_source.dart';
import 'package:dark_knights/features/feeds/data/repositories/feed_repository_implementation.dart';
import 'package:dark_knights/features/feeds/domain/repositories/feed_repository.dart';
import 'package:dark_knights/features/feeds/domain/usecases/get_articles.dart';
import 'package:dark_knights/features/feeds/domain/usecases/filter_articles.dart';
import 'package:dark_knights/features/feeds/domain/usecases/search_articles.dart';
import 'package:dark_knights/features/feeds/presentation/bloc/feed_bloc.dart';
import 'package:get_it/get_it.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;

final sl = GetIt.instance;
Future<void> feedInjectionInit() async {
//Bloc
  sl.registerFactory(() => FeedBloc(
      getArticles: sl(),
      searchArticles: sl(),
      filterArticles: sl(),
      getArticleById: sl()));
// usecases
  sl.registerLazySingleton(() => FilterArticles(repository: sl()));
  sl.registerLazySingleton(() => GetArticles(repository: sl()));
  sl.registerLazySingleton(() => SearchArticles(repository: sl()));

//Repository

  sl.registerLazySingleton<FeedRepository>(
      () => FeedRepositoryImplementation(remoteDataSource: sl()));
//Data sources
  sl.registerLazySingleton<FeedRemoteDataSource>(
      () => FeedRemoteDataSourceImplementation(client: sl()));

// ignore: non_constant_identifier_names
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
}
