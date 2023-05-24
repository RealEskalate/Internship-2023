import '../../../domain/entities/city_entity.dart';

abstract class SearchState {}

class SearchInitialState extends SearchState {}

class SearchLoadingState extends SearchState {}

class SearchSuccessState extends SearchState {
  final City city;
  SearchSuccessState({required this.city});
}

class SearchFailureState extends SearchState {
  final String error;
  SearchFailureState({required this.error});
}
