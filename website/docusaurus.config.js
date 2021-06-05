/** @type {import('@docusaurus/types').DocusaurusConfig} */
module.exports = {
  title: 'Project Weekend Puzzles',
  tagline: 'PoC of composable, reactive UI with gRPC-driven API',
  url: 'https://github.com/NikodemMazur/project-weekend-puzzles/',
  baseUrl: '/',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/pwp_logo.svg',
  organizationName: 'NikodemMazur', // Usually your GitHub org/user name.
  projectName: 'project-weekend-puzzles', // Usually your repo name.
  themeConfig: {
    prism: {
      additionalLanguages: ['csharp', 'powershell'],
    },
    navbar: {
      title: 'Project Weekend Puzzles',
      logo: {
        alt: 'My Site Logo',
        src: 'img/pwp_logo.svg',
      },
      items: [
        {
          type: 'doc',
          docId: 'what',
          position: 'left',
          label: 'Documentation',
        },
        {
          href: 'https://github.com/NikodemMazur/project-weekend-puzzles/',
          label: 'GitHub',
          position: 'right',
        },
      ],
    },
    footer: {
      style: 'dark',
      links: [
        {
          title: 'Docs',
          items: [
            {
              label: 'Documentation',
              to: '/docs/what',
            },
          ],
        },
        {
          title: 'Tech stack',
          items: [
            {
              label: 'Prism',
              href: 'https://prismlibrary.com/',
            },
            {
              label: 'ReactiveUI',
              href: 'https://www.reactiveui.net/',
            },
            {
              label: '.NET 5 WPF',
              href: 'https://docs.microsoft.com/en-us/dotnet/desktop/wpf/?view=netdesktop-5.0',
            },
            {
              label: 'ASP.NET Core',
              href: 'https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0',
            },
            {
              label: 'gRPC',
              href: 'https://grpc.io/',
            },
            {
              label: 'Material Design in XAML',
              href: 'http://materialdesigninxaml.net/',
            },
          ],
        },
        {
          title: 'More',
          items: [
            {
              label: 'GitHub',
              href: 'https://github.com/NikodemMazur/project-weekend-puzzles/',
            },
          ],
        },
      ],
      copyright: `MIT License, ${new Date().getFullYear()} Nikodem Mazur. Docs built with Docusaurus.`,
    },
  },
  presets: [
    [
      '@docusaurus/preset-classic',
      {
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          // Please change this to your repo.
          editUrl:
            'https://github.com/NikodemMazur/project-weekend-puzzles/edit/docs/docs/pwp-docs/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
