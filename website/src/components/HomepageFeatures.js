import React from 'react';
import clsx from 'clsx';
import styles from './HomepageFeatures.module.css';

const FeatureList = [
  {
    title: 'Easy to Extend',
    Svg: require('../../static/img/composability.svg').default,
    description: (
      <>
        Built on the top of Prism, Project Weekend Puzzles lets you easily meet the application
        requirements by composing the UI of custom zero-coupled modules.
      </>
    ),
  },
  {
    title: 'Controlled through API',
    Svg: require('../../static/img/api.svg').default,
    description: (
      <>
        Playing purely presentational role, Project Weekend Puzzles' content is fully controlled with the
        technology-agnostic API driven by gRPC.
      </>
    ),
  },
  {
    title: 'Authorized with RBAC',
    Svg: require('../../static/img/auth_borderless.svg').default,
    description: (
      <>
        Authorization takes place on two basis
      </>
    ),
  },
];

function Feature({Svg, title, description}) {
  return (
    <div className={clsx('col col--4')}>
      <div className="text--center">
        <Svg className={styles.featureSvg} alt={title} />
      </div>
      <div className="text--center padding-horiz--md">
        <h3>{title}</h3>
        <p>{description}</p>
      </div>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          {FeatureList.map((props, idx) => (
            <Feature key={idx} {...props} />
          ))}
        </div>
      </div>
    </section>
  );
}
