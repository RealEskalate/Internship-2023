import 'package:equatable/equatable.dart';

class CityWeather extends Equatable {
  final String cityName;
  final double temperature;
  final double humidity;
  final String weatherDescription;

  const CityWeather({
    required this.cityName,
    required this.temperature,
    required this.humidity,
    required this.weatherDescription,
  });
  
  @override
  // TODO: implement props
  List<Object?> get props => [cityName, temperature, humidity, weatherDescription];
}


// import 'package:dartsmiths/features/articles/domain/entity/article.dart';
// import 'package:dartsmiths/features/articles/domain/repository/article_repository.dart';
// import 'package:dartz/dartz.dart';

// import '../../../../core/usecases/usecase.dart';


// // Create Article UseCase
// class CreateArticleUsecase implements UseCase<Article, ArticleParams> {
//   final ArticleRepository repository;

//   @override
//   Future<Either<Failure, Article>> call(ArticleParams params) async {
//     return await repository.createArticle(article: params.article);
//   }

//   CreateArticleUsecase(this.repository);
// }