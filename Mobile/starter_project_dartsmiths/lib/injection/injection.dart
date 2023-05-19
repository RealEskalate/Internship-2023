import 'package:dartsmiths/features/authentication/data/datasource/authentication_remote_datasource.dart';
import 'package:get_it/get_it.dart';
import 'package:internet_connection_checker/internet_connection_checker.dart';
import 'package:http/http.dart' as http;
import '../core/network/network_info.dart';
import '../features/authentication/data/repository/authentication_repository_impl.dart';
import '../features/authentication/domain/repository/login_repository.dart';
import '../features/authentication/domain/use_cases/login_usecase.dart';
import '../features/authentication/presentation/bloc/auth_bloc.dart';

final serviceLocator = GetIt.instance;

void init() {
  //! Features

  //?Bloc
  serviceLocator.registerFactory(() => AuthBloc(serviceLocator()));

  //?Usecase
  serviceLocator.registerSingleton(() => LoginUsecase(serviceLocator()));

  //?Repositories
  serviceLocator.registerLazySingleton<AuthenticationRepository>(() =>
      AuthenticationRepositoryImpl(
          remotedataSource: serviceLocator(), networkInfo: serviceLocator()));
  //?DataSource

  serviceLocator.registerLazySingleton<AuthenticationRemoteDataSource>(
      () => AuthenticationRemoteDataSourceImpl(serviceLocator()));

  //! Core
  serviceLocator.registerLazySingleton<NetworkInfo>(
      () => NetworkInfoImpl(serviceLocator()));

  //! External
  serviceLocator.registerLazySingleton(() => http.Client());

  serviceLocator.registerLazySingleton(() => InternetConnectionChecker());
}
