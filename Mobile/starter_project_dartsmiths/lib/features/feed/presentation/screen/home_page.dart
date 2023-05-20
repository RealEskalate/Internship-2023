import 'package:dartsmiths/core/utils/colors.dart';
import 'package:dartsmiths/core/utils/ui_converter.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_bloc.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_event.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/home_state.dart';
import 'package:dartsmiths/features/feed/presentation/bloc/search_status.dart';
import 'package:dartsmiths/features/feed/presentation/widgets/search_bar.dart';
import 'package:dartsmiths/injection/injection.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_svg/svg.dart';
import '../../../../core/utils/style.dart';
import '../widgets/add_button.dart';
import '../widgets/filter_button.dart';
import '../widgets/article_card.dart';
import '../widgets/profile.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {

  final TextEditingController _controller = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) => serviceLocator<SearchBloc>()..add(SearchSubmitted()),
      child: Scaffold(
        floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
        appBar: AppBar(
          elevation: 0,
          backgroundColor: whiteColor,
          leading: Padding(
              padding: EdgeInsets.only(
                bottom: UIConverter.getComponentHeight(context, 15),
                top: UIConverter.getComponentHeight(context, 15),
                right: UIConverter.getComponentWidth(context, 15),
                left: UIConverter.getComponentWidth(context, 15),
              ),
              child: SizedBox(
                  height: UIConverter.getComponentHeight(context, 35),
                  width: UIConverter.getComponentWidth(context, 35),
                  child: SvgPicture.asset("images/menu_bar.svg"))),
          title: Center(
              child: Text("Welcome  Back!",
                  style: myTextStyle.copyWith(
                      color: blackColor,
                      fontSize: 25,
                      fontWeight: FontWeight.w800))),
          actions: const [ProfileAvatar()],
        ),
        body: BlocConsumer<SearchBloc, SearchState>(
          listener: (context, state) {},
          builder: (context, state) {
            if (state.searchSubmissionStatus is SearchSubmittingStatus) {
              return CircularProgressIndicator(
                color: contentBgColor,
                backgroundColor: Colors.orange[900],
              );
            }
            if (state.searchSubmissionStatus is SearchSubmissionSuccess) {
              return SizedBox(
                height: double.infinity,
                child: Column(
                  children: [
                    Searchbar(controller: _controller),
                    Padding(
                      padding: EdgeInsets.only(
                        top: UIConverter.getComponentHeight(context, 20),
                        right: UIConverter.getComponentWidth(context, 25),
                        left: UIConverter.getComponentWidth(context, 25),
                      ),
                      child: const FilterButton(
                      ),
                    ),
                    Expanded(
                      child: ListView(
                        children: [
                          const ArticleCard(),
                          const ArticleCard(),
                          SizedBox(
                            height: UIConverter.getComponentHeight(context, 70),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
              );
            }
            return const CircularProgressIndicator();
          },
        ),
        floatingActionButton: const AddButton(),
      ),
    );
  }
}
