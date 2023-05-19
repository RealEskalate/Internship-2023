import 'package:dartsmiths/features/article/presentation/bloc/article_bloc.dart';
import 'package:data_connection_checker/data_connection_checker.dart';
import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';

import '../core/network/intwork_info.dart';
import '../features/article/data/datasources/article_remote_data_source.dart';
import '../features/article/data/repositories/article_repository_impl.dart';
import '../features/article/domain/repositories/article_repository.dart';
import '../features/article/domain/usecases/get_article.dart';
import '../features/article/domain/usecases/post_article.dart';
import '../features/article/domain/usecases/update_article.dart';
// import '../features';

final sl = GetIt.instance;

Future<void> init() async {

  // sl.registerFactory(
  //   () => ArticleBloc(postArticle: sl(), updateArticle:sl(), getArticle:sl())
  // );

  sl.registerFactory(() => ArticleBloc(postArticle: sl(), updateArticle: sl(), getArticle: sl()));

  // Use cases
  sl.registerLazySingleton(() => GetArticle(sl()));
  sl.registerLazySingleton(() => PostArticle(sl()));
  sl.registerLazySingleton(() => UpdateArticle(sl()));

  // Repository
  sl.registerLazySingleton<ArticleRepositoryImpl>(
    () =>ArticleRepositoryImpl(articleRemoteDataSource: sl(), networkInfo: sl()));
  // Data sources
  sl.registerLazySingleton<ArticleRemoteDataSource>(
    () => ArticleRemoteDataSourceImpl(client: sl()),
  );


  // Core
  sl.registerLazySingleton<NetworkInfo>(() => NetworkInfoImpl(sl()));

  // External
  final sharedPreferences = await SharedPreferences.getInstance();
  sl.registerLazySingleton(() => sharedPreferences);
  sl.registerLazySingleton(() => http.Client());
  sl.registerLazySingleton(() => DataConnectionChecker());
}