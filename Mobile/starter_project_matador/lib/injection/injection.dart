// Importing the get_it library for Flutter
import 'package:get_it/get_it.dart';
import 'package:http/http.dart' as http;
import 'package:matador/features/article/data/datasources/article_remote_data_source.dart';
import 'package:matador/features/article/data/repositories/article_repository_impl.dart';
import 'package:matador/features/article/domain/repositories/article_repository.dart';
import 'package:matador/features/article/domain/usecases/get_all_articles.dart';
import 'package:matador/features/article/domain/usecases/get_article_by_id.dart';
import 'package:matador/features/article/presentation/bloc/article_bloc.dart';
import 'package:matador/features/feed/presentation/block/feed_bloc.dart';
import 'package:matador/features/user/data/datasources/user_remote_data_source.dart';
import 'package:matador/features/user/data/repositories/user_repository_imp.dart';
import 'package:matador/features/user/domain/entities/user.dart';
import 'package:matador/features/user/domain/repositories/user_repository.dart';

import '../features/auth/data/datasources/login_remote_datasource.dart';
import '../features/auth/data/repositories/login_user_repository_impl.dart';
import '../features/auth/domain/repositories/login_repository.dart';
import '../features/auth/domain/usecases/login_use_case.dart';
import '../features/auth/presentation/bloc/login_bloc.dart';
import '../features/user/presentation/bloc/user_bloc.dart';

// Creating a new instance of GetIt
final sl = GetIt.instance;

void init() {
  // Registering the LoginUserUseCase as a lazy singleton
  sl.registerLazySingleton(() => LoginUserUseCase(sl()));
  sl.registerLazySingleton(() => GetAllArticles(sl()));
  sl.registerLazySingleton(() => GetArticleById(sl()));

  // Registering the LoginUserRepositoryImpl as a lazy singleton
  sl.registerLazySingleton<LoginUserRepository>(
      () => LoginUserRepositoryImpl(remoteDataSource: sl()));
  sl.registerLazySingleton<UserRepository>(
      () => UserRepositoryImpl(remoteDataSource: sl()));
  sl.registerLazySingleton<ArticleRepository>(
      () => ArticleRepositoryImpl(remoteDataSource: sl()));

  // Registering the LoginUserRemoteDataSourceImpl as a lazy singleton
  sl.registerLazySingleton<LoginRemoteDataSource>(
      () => LoginRemoteDataSourceImpl(httpClient: sl()));
  sl.registerLazySingleton<UserRemoteDataSource>(
      () => UserRemoteDataSourceImpl(client: sl()));
  sl.registerLazySingleton<ArticleRemoteDataSource>(
      () => ArticleRemoteDataSourceImpl(client: sl()));

  // Registering the LoginBloc as a factory
  sl.registerFactory(() => LoginBloc(loginUseCase: sl()));
  sl.registerFactory(() => UserBloc(
      addUser: sl(),
      getUserById: sl(),
      editUserById: sl(),
      deleteUserById: sl()));
  sl.registerFactory(() => ArticleBloc(getArticle: sl()));
  sl.registerFactory(() => FeedBloc(getAllArticles: sl()));
  // Registering the http client as a lazy singleton
  sl.registerLazySingleton(() => http.Client());
}
