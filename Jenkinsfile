
import org.apache.commons.lang.StringUtils


pipeline {
    agent {
        label "v-s6-k8s-n2"
    }
       options { timestamps () }

    stages {
        stage('build and push') {
            steps {
                sh """
					cd ${workspace}
					docker build -f WebApplication1\Dockerfile -t rickandmortapp .
					// docker push ${registry}/rickandmortapp
				"""
            }
        }

    } // end of stages
   post {
		always {
			echo 'One way or another, I have finished'
			
				
			
		}
        success {
            echo 'I succeeeded!'
               
           
        }
        unstable {
            echo 'I am unstable :/'
        }
        failure {
            echo 'I failed :('
            
            }
        changed {
             echo 'Things were different before...'
        }
    
       
    } // end of post
} // end of pipeline
