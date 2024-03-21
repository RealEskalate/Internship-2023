import 'package:dark_knights/core/network/network_info.dart';
import 'package:dark_knights/features/article/data/datasources/article_remote_data_source.dart';
import 'package:dark_knights/features/article/domain/usecases/get_article_by_id.dart';
import 'package:get_it/get_it.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import 'package:internet_connection_checker/internet_connection_checker.dart';

import 'features/article/data/datasources/article_local_data_source.dart';
import 'features/article/data/repositories/article_repository_impl.dart';
import 'features/article/domain/repositories/article_repository.dart';
import 'features/article/domain/usecases/delete_article.dart';
import 'features/article/domain/usecases/get_articles_by_user_id.dart';
import 'features/article/domain/usecases/post_article.dart';
import 'features/article/domain/usecases/update_articles.dart';
import 'features/article/presentation/bloc/article_bloc.dart';

final sl = GetIt.instance;
Future<void> articleInjectionInit() async {
  // Bloc
  sl.registerFactory(
    () => ArticleBloc(
        getArticleById: sl(),
        deleteArticle: sl(),
        getArticleByUserId: sl(),
        postArticle: sl(),
        updateArticle: sl(),
        repository: sl()),
  );

  // usecases
  sl.registerLazySingleton(
    () => GetArticleById(repository: sl()),
  );

  sl.registerLazySingleton(
    () => GetArticlesByUserId(repository: sl()),
  );

  sl.registerLazySingleton(
    () => DeleteArticle(repository: sl()),
  );

  sl.registerLazySingleton(
    () => PostArticle(repository: sl()),
  );

  sl.registerLazySingleton(
    () => UpdateArticle(repository: sl()),
  );

  // Repository
  sl.registerLazySingleton<ArticleRepository>(
    () => ArticleRepositoryImpl(
      localDataSource: sl(),
      remoteDataSource: sl(),
      networkInfo: sl(),
    ),
  );

  // Data Sources
  sl.registerLazySingleton<ArticleRemoteDataSource>(
    () => ArticleRemoteDataSourceImpl(client: sl()),
  );

  sl.registerLazySingleton<ArticleLocalDataSource>(
    () => ArticleLocalDataSourceImpl(sharedPreferences: sl()),
  );

  //core
  sl.registerLazySingleton<NetworkInfo>(
    () => NetworkInfoImpl(sl()),
  );

  //external
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => InternetConnectionChecker());
}
